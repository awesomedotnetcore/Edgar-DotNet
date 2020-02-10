(window.webpackJsonp=window.webpackJsonp||[]).push([[4],{124:function(e,t,r){"use strict";r.r(t),r.d(t,"frontMatter",(function(){return l})),r.d(t,"metadata",(function(){return s})),r.d(t,"rightToc",(function(){return u})),r.d(t,"default",(function(){return b}));var n=r(1),o=r(9),a=(r(0),r(150)),i=r(152),c=r(158),l={id:"introduction",title:"Introduction",sidebar_label:"Introduction"},s={id:"introduction",title:"Introduction",description:'import useBaseUrl from "@docusaurus/useBaseUrl";\r',source:"@site/docs\\introduction.md",permalink:"/ProceduralLevelGenerator/docs/introduction",editUrl:"https://github.com/OndrejNepozitek/ProceduralLevelGenerator/tree/docusaurus/docs/introduction.md",sidebar_label:"Introduction",sidebar:"someSidebar",next:{title:"Installation",permalink:"/ProceduralLevelGenerator/docs/installation"}},u=[{value:"Features",id:"features",children:[]},{value:"Inspiration",id:"inspiration",children:[]},{value:"Examples",id:"examples",children:[{value:"Input",id:"input",children:[]},{value:"Results",id:"results",children:[]}]}],p={rightToc:u};function b(e){var t=e.components,r=Object(o.a)(e,["components"]);return Object(a.b)("wrapper",Object(n.a)({},p,r,{components:t,mdxType:"MDXLayout"}),Object(a.b)("p",null,"This project is a library for procedural generation of 2D layouts based on a graph of rooms connections."),Object(a.b)("p",null,"To produce a game level, the algorithm takes a set of polygonal building blocks and a level connectivity graph (the level topology) as an input. Nodes in the graph represent rooms, and edges define connectivities between them. The graph has to be planar. The goal of the algorithm is to assign a room shape and a position to each node in the graph in a way that no two room shapes intersect and every pair of neighbouring room shapes can be connected by doors."),Object(a.b)("p",null,"See the ",Object(a.b)("a",Object(n.a)({parentName:"p"},{href:"/ProceduralLevelGenerator/docs/guides"}),"Guides")," section to learn how to use the application and the ",Object(a.b)("a",Object(n.a)({parentName:"p"},{href:"/ProceduralLevelGenerator/docs/chainBasedGenerator"}),"Chain based generator")," section if you want to find out how it all works or plan to extend the generator."),Object(a.b)("h2",{id:"features"},"Features"),Object(a.b)("ul",null,Object(a.b)("li",{parentName:"ul"},"Any planar connected graph can be used as an input"),Object(a.b)("li",{parentName:"ul"},"Any orthogonal polygon can be used as a room shape"),Object(a.b)("li",{parentName:"ul"},"Complete control over shapes of individual rooms"),Object(a.b)("li",{parentName:"ul"},"Complete control over door positions of individual room shapes"),Object(a.b)("li",{parentName:"ul"},"Rooms either directly connected by doors or connected by corridors"),Object(a.b)("li",{parentName:"ul"},"Export to JSON, SVG, JPG"),Object(a.b)("li",{parentName:"ul"},"Majority of features available through a GUI and YAML config files"),Object(a.b)("li",{parentName:"ul"},"Implicit support for keys and locks - just define the connectivity graph hovewer you like")),Object(a.b)("h2",{id:"inspiration"},"Inspiration"),Object(a.b)("p",null,"The main idea of the algorithm used in this library comes from a ",Object(a.b)("a",Object(n.a)({parentName:"p"},{href:"http://chongyangma.com/publications/gl/index.html"}),"paper")," written by ",Object(a.b)("strong",{parentName:"p"},"Chongyang Ma")," and colleagues so be sure to check their work out."),Object(a.b)("p",null,"Some things in this library are done differently and/or improved:"),Object(a.b)("ul",null,Object(a.b)("li",{parentName:"ul"},Object(a.b)("strong",{parentName:"li"},"Integer coordinates")," are used instead of reals - room shapes are therefore only orthogonal polygons."),Object(a.b)("li",{parentName:"ul"},"With integer coordinates, ",Object(a.b)("strong",{parentName:"li"},"optimized polygon operations")," (intersections, etc..) were implemented with a complete control over the process."),Object(a.b)("li",{parentName:"ul"},"User has a complete control over door positions of rooms."),Object(a.b)("li",{parentName:"ul"},"The algorithm was optimized to generate a layout as fast as possible."),Object(a.b)("li",{parentName:"ul"},"A specialized version of the generator was implemented to support ",Object(a.b)("strong",{parentName:"li"},"adding (usally) short corridors")," between rooms to the layout without sacrificing most of the convergence speed. (Average number of iterations usually stays the same but iterations themselves are slower.)")),Object(a.b)("h2",{id:"examples"},"Examples"),Object(a.b)("h3",{id:"input"},"Input"),Object(a.b)("img",{alt:"Docusaurus with Keytar",src:Object(i.a)("img/introduction/introduction.svg")}),";",Object(a.b)("h3",{id:"results"},"Results"),Object(a.b)(c.a,{cols:2,mdxType:"Gallery"},Object(a.b)(c.b,{src:"img/introduction/0.jpg",mdxType:"GalleryImage"}),Object(a.b)(c.b,{src:"img/introduction/1.jpg",mdxType:"GalleryImage"}),Object(a.b)(c.b,{src:"img/introduction/2.jpg",mdxType:"GalleryImage"}),Object(a.b)(c.b,{src:"img/introduction/3.jpg",mdxType:"GalleryImage"})),Object(a.b)("p",null,Object(a.b)("strong",{parentName:"p"},"Note:")," Click on images to see them in full size."))}b.isMDXComponent=!0},150:function(e,t,r){"use strict";r.d(t,"a",(function(){return p})),r.d(t,"b",(function(){return m}));var n=r(0),o=r.n(n);function a(e,t,r){return t in e?Object.defineProperty(e,t,{value:r,enumerable:!0,configurable:!0,writable:!0}):e[t]=r,e}function i(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function c(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?i(Object(r),!0).forEach((function(t){a(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):i(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}function l(e,t){if(null==e)return{};var r,n,o=function(e,t){if(null==e)return{};var r,n,o={},a=Object.keys(e);for(n=0;n<a.length;n++)r=a[n],t.indexOf(r)>=0||(o[r]=e[r]);return o}(e,t);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);for(n=0;n<a.length;n++)r=a[n],t.indexOf(r)>=0||Object.prototype.propertyIsEnumerable.call(e,r)&&(o[r]=e[r])}return o}var s=o.a.createContext({}),u=function(e){var t=o.a.useContext(s),r=t;return e&&(r="function"==typeof e?e(t):c({},t,{},e)),r},p=function(e){var t=u(e.components);return o.a.createElement(s.Provider,{value:t},e.children)},b={inlineCode:"code",wrapper:function(e){var t=e.children;return o.a.createElement(o.a.Fragment,{},t)}},d=Object(n.forwardRef)((function(e,t){var r=e.components,n=e.mdxType,a=e.originalType,i=e.parentName,s=l(e,["components","mdxType","originalType","parentName"]),p=u(r),d=n,m=p["".concat(i,".").concat(d)]||p[d]||b[d]||a;return r?o.a.createElement(m,c({ref:t},s,{components:r})):o.a.createElement(m,c({ref:t},s))}));function m(e,t){var r=arguments,n=t&&t.mdxType;if("string"==typeof e||n){var a=r.length,i=new Array(a);i[0]=d;var c={};for(var l in t)hasOwnProperty.call(t,l)&&(c[l]=t[l]);c.originalType=e,c.mdxType="string"==typeof e?e:n,i[1]=c;for(var s=2;s<a;s++)i[s]=r[s];return o.a.createElement.apply(null,i)}return o.a.createElement.apply(null,r)}d.displayName="MDXCreateElement"},151:function(e,t,r){"use strict";var n=r(0),o=r(48);t.a=function(){return Object(n.useContext)(o.a)}},152:function(e,t,r){"use strict";r.d(t,"a",(function(){return o}));r(156);var n=r(151);function o(e){var t=(Object(n.a)().siteConfig||{}).baseUrl,r=void 0===t?"/":t;if(!e)return e;return/^(https?:|\/\/)/.test(e)?e:e.startsWith("/")?r+e.slice(1):r+e}},154:function(e,t,r){var n=r(66),o=r(23);e.exports=function(e,t,r){if(n(t))throw TypeError("String#"+r+" doesn't accept regex!");return String(o(e))}},155:function(e,t,r){var n=r(2)("match");e.exports=function(e){var t=/./;try{"/./"[e](t)}catch(r){try{return t[n]=!1,!"/./"[e](t)}catch(o){}}return!0}},156:function(e,t,r){"use strict";var n=r(17),o=r(34),a=r(154),i="".startsWith;n(n.P+n.F*r(155)("startsWith"),"String",{startsWith:function(e){var t=a(this,e,"startsWith"),r=o(Math.min(arguments.length>1?arguments[1]:void 0,t.length)),n=String(e);return i?i.call(t,n,r):t.slice(r,r+n.length)===n}})},158:function(e,t,r){"use strict";r.d(t,"a",(function(){return c})),r.d(t,"b",(function(){return l}));var n=r(0),o=r.n(n),a=r(152),i=function(e){return o.a.createElement("div",{style:{display:"inline-block",margin:2,overflow:"hidden",position:"relative",width:"calc("+100/e.cols+"% - 4px)"}},e.children)},c=function(e){return o.a.createElement("div",{style:{fontSize:"0px"}},o.a.Children.map(e.children,(function(t){return o.a.cloneElement(t,{cols:e.cols||4})})))},l=function(e){return o.a.createElement("a",{href:Object(a.a)(e.src),target:"_blank"},o.a.createElement(i,{cols:e.cols},o.a.createElement("img",{src:Object(a.a)(e.src),alt:"result"})))}}}]);