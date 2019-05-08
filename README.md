# clipper_test
Today I was looking for a library for Boolean and offsetting operations on polygons and I stumbled upon this little library called [Clipper](http://www.angusj.com/delphi/clipper.php) by
Angus Johnson.

It is distributed in source form in various languages including C# and is freeware both for opensource and commercial applications.

I needed to solve this problem: 

* Offset a rectangular polygon by a fixed amount, rounding corners.
* Intersect the previous polygon with a second polygon.
* Compute area and perimeter of resulting polygon.
This is needed to solve a problem in civil engineering about punching of columns through slabs in case of corner or border columns.

I put together this small demo app in Vb.Net to test this library.
