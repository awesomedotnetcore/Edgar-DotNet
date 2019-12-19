﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MapGeneration.Interfaces.Core.ChainDecompositions;
using MapGeneration.Interfaces.Core.GeneratorPlanners;
using MapGeneration.Interfaces.Core.LayoutConverters;
using MapGeneration.Interfaces.Core.LayoutEvolvers;
using MapGeneration.Interfaces.Core.LayoutGenerator;
using MapGeneration.Interfaces.Utils;

namespace MapGeneration.Core.LayoutGenerators
{
    public class SimpleChainBasedGenerator<TMapDescription, TLayout, TOutputLayout, TNode> : IBenchmarkableLayoutGenerator<TMapDescription, TOutputLayout>, IRandomInjectable, ICancellable
    {
        private readonly TLayout initialLayout;
        private readonly IGeneratorPlanner<TLayout, TNode> generatorPlanner;
        private readonly IList<IChain<TNode>> chains;
        private readonly ILayoutEvolver<TLayout, TNode> layoutEvolver;
        private readonly ILayoutConverter<TLayout, TOutputLayout> layoutConverter;

        protected Random Random = new Random();
        protected CancellationToken? CancellationToken;

        public event Action<Random> OnRandomInjected; 
        public event Action<CancellationToken> OnCancellationTokenInjected; 

        public SimpleChainBasedGenerator(TLayout initialLayout, IGeneratorPlanner<TLayout, TNode> generatorPlanner, IList<IChain<TNode>> chains, ILayoutEvolver<TLayout, TNode> layoutEvolver, ILayoutConverter<TLayout, TOutputLayout> layoutConverter)
        {
            this.initialLayout = initialLayout;
            this.generatorPlanner = generatorPlanner;
            this.chains = chains;
            this.layoutEvolver = layoutEvolver;
            this.layoutConverter = layoutConverter;
        }

        public IList<TOutputLayout> GetLayouts(TMapDescription mapDescription, int numberOfLayouts)
        {
            if (numberOfLayouts != 1) 
                throw new InvalidOperationException();

            IterationsCount = 0;
            layoutEvolver.OnPerturbed += IterationsCounterHandler;

            OnRandomInjected?.Invoke(Random);

            if (CancellationToken.HasValue)
            {
                OnCancellationTokenInjected?.Invoke(CancellationToken.Value);
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var layout = generatorPlanner.Generate(initialLayout, chains, layoutEvolver);

            stopwatch.Stop();

            layoutEvolver.OnPerturbed -= IterationsCounterHandler;
            LayoutsCount = 1;
            TimeTotal = stopwatch.ElapsedMilliseconds;

            // Reset cancellation token if it was already used
            if (CancellationToken.HasValue && CancellationToken.Value.IsCancellationRequested)
            {
                CancellationToken = null;
            }

            var convertedLayout = layout != null ? layoutConverter.Convert(layout, true) : default(TOutputLayout);

            return new List<TOutputLayout>() {convertedLayout};
        }

        private void IterationsCounterHandler(object sender, TLayout layout)
        {
            IterationsCount++;
        }

        public long TimeFirst => throw new InvalidOperationException();

        public long TimeTotal { get; private set; }

        public int IterationsCount { get; private set; }

        public int LayoutsCount { get; private set; }

        public void EnableBenchmark(bool enable)
        {
            
        }

        /// <summary>
        /// Checks if a given object is IRandomInjectable and/or ICancellable
        /// and tries to inject a random generator or a cancellation token.
        /// </summary>
        /// <param name="o"></param>
        protected void TryInjectRandomAndCancellationToken(object o)
        {
            if (o is IRandomInjectable randomInjectable)
            {
                randomInjectable.InjectRandomGenerator(Random);
            }

            if (CancellationToken.HasValue && o is ICancellable cancellable)
            {
                cancellable.SetCancellationToken(CancellationToken.Value);
            }
        }

        public void InjectRandomGenerator(Random random)
        {
            Random = random;
        }

        public void SetCancellationToken(CancellationToken? cancellationToken)
        {
            CancellationToken = cancellationToken;
        }
    }
}