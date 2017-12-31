﻿namespace GeneralAlgorithms.Tests.Algorithms.Common
{
	using System.Collections.Generic;
	using System.Linq;
	using GeneralAlgorithms.Algorithms.Common;
	using GeneralAlgorithms.DataStructures.Common;
	using NUnit.Framework;

	[TestFixture]
	public class LineSegmentIntersectionTests
	{
		private LineSegmentIntersection lineSegmentIntersection;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			lineSegmentIntersection = new LineSegmentIntersection();
		}

		[Test]
		public void TryGetIntersection_HorizontalLines()
		{
			{
				// No intersection - different Y
				var line1 = new OrthogonalLine(new IntVector2(1, 1), new IntVector2(5, 1));
				var line2 = new OrthogonalLine(new IntVector2(1, 2), new IntVector2(5, 2));

				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line1, line2, out var intersection1));
				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line1.SwitchOrientation(), line2.SwitchOrientation(), out var intersection2));

				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line2, line1, out var intersection3));
				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line2.SwitchOrientation(), line1.SwitchOrientation(), out var intersection4));
			}

			{
				// No intersection - same Y
				var line1 = new OrthogonalLine(new IntVector2(1, 1), new IntVector2(5, 1));
				var line2 = new OrthogonalLine(new IntVector2(6, 1), new IntVector2(8, 1));

				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line1, line2, out var intersection1));
				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line1.SwitchOrientation(), line2.SwitchOrientation(), out var intersection2));

				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line2, line1, out var intersection3));
				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line2.SwitchOrientation(), line1.SwitchOrientation(), out var intersection4));
			}

			{
				// Intersection is one point
				var line1 = new OrthogonalLine(new IntVector2(1, 1), new IntVector2(5, 1));
				var line2 = new OrthogonalLine(new IntVector2(5, 1), new IntVector2(10, 1));
				var expected = new OrthogonalLine(new IntVector2(5, 1), new IntVector2(5, 1));

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line1, line2, out var intersection1));
				Assert.AreEqual(expected, intersection1.GetNormalized());

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line1.SwitchOrientation(), line2.SwitchOrientation(), out var intersection2));
				Assert.AreEqual(expected, intersection2.GetNormalized());

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line2, line1, out var intersection3));
				Assert.AreEqual(expected, intersection3.GetNormalized());

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line2.SwitchOrientation(), line1.SwitchOrientation(), out var intersection4));
				Assert.AreEqual(expected, intersection4.GetNormalized());
			}

			{
				// Intersection is a line
				var line1 = new OrthogonalLine(new IntVector2(3, 2), new IntVector2(10, 2));
				var line2 = new OrthogonalLine(new IntVector2(7, 2), new IntVector2(13, 2));
				var expected = new OrthogonalLine(new IntVector2(7, 2), new IntVector2(10, 2)).GetNormalized();

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line1, line2, out var intersection1));
				Assert.AreEqual(expected, intersection1.GetNormalized());

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line1.SwitchOrientation(), line2.SwitchOrientation(), out var intersection2));
				Assert.AreEqual(expected, intersection2.GetNormalized());

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line2, line1, out var intersection3));
				Assert.AreEqual(expected, intersection3.GetNormalized());

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line2.SwitchOrientation(), line1.SwitchOrientation(), out var intersection4));
				Assert.AreEqual(expected, intersection4.GetNormalized());
			}
		}

		[Test]
		public void TryGetIntersection_VerticalLines()
		{
			{
				// No intersection - different Y
				var line1 = new OrthogonalLine(new IntVector2(1, 1), new IntVector2(5, 1)).Rotate(90);
				var line2 = new OrthogonalLine(new IntVector2(1, 2), new IntVector2(5, 2)).Rotate(90);

				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line1, line2, out var intersection1));
				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line1.SwitchOrientation(), line2.SwitchOrientation(), out var intersection2));

				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line2, line1, out var intersection3));
				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line2.SwitchOrientation(), line1.SwitchOrientation(), out var intersection4));
			}

			{
				// No intersection - same Y
				var line1 = new OrthogonalLine(new IntVector2(1, 1), new IntVector2(5, 1)).Rotate(90);
				var line2 = new OrthogonalLine(new IntVector2(6, 1), new IntVector2(8, 1)).Rotate(90);

				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line1, line2, out var intersection1));
				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line1.SwitchOrientation(), line2.SwitchOrientation(), out var intersection2));

				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line2, line1, out var intersection3));
				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line2.SwitchOrientation(), line1.SwitchOrientation(), out var intersection4));
			}

			{
				// Intersection is one point
				var line1 = new OrthogonalLine(new IntVector2(1, 1), new IntVector2(5, 1)).Rotate(90);
				var line2 = new OrthogonalLine(new IntVector2(5, 1), new IntVector2(10, 1)).Rotate(90);
				var expected = new OrthogonalLine(new IntVector2(5, 1), new IntVector2(5, 1), OrthogonalLine.Direction.Bottom).Rotate(90);

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line1, line2, out var intersection1));
				Assert.AreEqual(expected, intersection1);

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line1.SwitchOrientation(), line2.SwitchOrientation(), out var intersection2));
				Assert.AreEqual(expected, intersection2);

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line2, line1, out var intersection3));
				Assert.AreEqual(expected, intersection3);

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line2.SwitchOrientation(), line1.SwitchOrientation(), out var intersection4));
				Assert.AreEqual(expected, intersection4);
			}

			{
				// Intersection is a line
				var line1 = new OrthogonalLine(new IntVector2(3, 2), new IntVector2(10, 2)).Rotate(90);
				var line2 = new OrthogonalLine(new IntVector2(7, 2), new IntVector2(13, 2)).Rotate(90);
				var expected = new OrthogonalLine(new IntVector2(7, 2), new IntVector2(10, 2)).Rotate(90).GetNormalized();

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line1, line2, out var intersection1));
				Assert.AreEqual(expected, intersection1.GetNormalized());

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line1.SwitchOrientation(), line2.SwitchOrientation(), out var intersection2));
				Assert.AreEqual(expected, intersection2.GetNormalized());

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line2, line1, out var intersection3));
				Assert.AreEqual(expected, intersection3.GetNormalized());

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line2.SwitchOrientation(), line1.SwitchOrientation(), out var intersection4));
				Assert.AreEqual(expected, intersection4.GetNormalized());
			}
		}

		[Test]
		public void TryGetIntersection_HorizontalAndVertical()
		{
			{
				// No intersection - one above the other
				var line1 = new OrthogonalLine(new IntVector2(1, 1), new IntVector2(5, 1));
				var line2 = new OrthogonalLine(new IntVector2(3, 2), new IntVector2(3, 7));

				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line1, line2, out var intersection1));
				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line1.SwitchOrientation(), line2.SwitchOrientation(), out var intersection2));

				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line2, line1, out var intersection3));
				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line2.SwitchOrientation(), line1.SwitchOrientation(), out var intersection4));
			}

			{
				// No intersection - one next to the other
				var line1 = new OrthogonalLine(new IntVector2(1, 1), new IntVector2(5, 1));
				var line2 = new OrthogonalLine(new IntVector2(6, 2), new IntVector2(6, 7));

				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line1, line2, out var intersection1));
				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line1.SwitchOrientation(), line2.SwitchOrientation(), out var intersection2));

				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line2, line1, out var intersection3));
				Assert.IsFalse(lineSegmentIntersection.TryGetIntersection(line2.SwitchOrientation(), line1.SwitchOrientation(), out var intersection4));
			}

			{
				// Intersection is one point
				var line1 = new OrthogonalLine(new IntVector2(1, 1), new IntVector2(5, 1));
				var line2 = new OrthogonalLine(new IntVector2(3, -2), new IntVector2(3, 5));
				var expected = new OrthogonalLine(new IntVector2(3, 1), new IntVector2(3, 1));

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line1, line2, out var intersection1));
				Assert.AreEqual(expected, intersection1);

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line1.SwitchOrientation(), line2.SwitchOrientation(), out var intersection2));
				Assert.AreEqual(expected, intersection2);

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line2, line1, out var intersection3));
				Assert.AreEqual(expected, intersection3);

				Assert.IsTrue(lineSegmentIntersection.TryGetIntersection(line2.SwitchOrientation(), line1.SwitchOrientation(), out var intersection4));
				Assert.AreEqual(expected, intersection4);
			}
		}

		[Test]
		public void GetIntersections()
		{
			var lines1 = new List<OrthogonalLine>()
			{
				new OrthogonalLine(new IntVector2(2, 1), new IntVector2(2, 7)),
				new OrthogonalLine(new IntVector2(3, 4), new IntVector2(8, 4)),
				new OrthogonalLine(new IntVector2(6, 5), new IntVector2(6, 8))
			};

			var lines2 = new List<OrthogonalLine>()
			{
				new OrthogonalLine(new IntVector2(1, 6), new IntVector2(7, 6)),
				new OrthogonalLine(new IntVector2(4, 4), new IntVector2(7, 4)),
				new OrthogonalLine(new IntVector2(8, 2), new IntVector2(8, 6))
			};

			var expected = new List<OrthogonalLine>()
			{
				new OrthogonalLine(new IntVector2(2, 6), new IntVector2(2, 6)),
				new OrthogonalLine(new IntVector2(4, 4), new IntVector2(7, 4)),
				new OrthogonalLine(new IntVector2(6, 6), new IntVector2(6, 6)),
				new OrthogonalLine(new IntVector2(8, 4), new IntVector2(8, 4)),
			};

			var intersection = lineSegmentIntersection.GetIntersections(lines1, lines2);

			Assert.IsTrue(expected.SequenceEqualWithoutOrder(intersection.Select(x => x.GetNormalized())));
		}
	}
}