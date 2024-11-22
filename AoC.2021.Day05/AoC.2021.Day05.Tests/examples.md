# example 1
## Line tests
- start and end can't be the same point
- 0,0 -> 0,1 is a valid vert line - length 2
- 0,0 -> 0,2 is a valid vert line - length 3
- 3,1 -> 3,-4 is a valid vert line - backward to negative
- 0,0 -> 1,0 is a valid horiz line - length 2
- 0,0 -> 2,0 is a valid horiz line - length 3
- 4,-1 -> 2,-1 is a valid horiz line - downward line
- 0,0 -> 1,1 is not valid
- 0,0 -> 2,1 is not valid
- 0,0 -> -1,-2 is not valid



## Grid tests

- horizontal overlaps with empty map on no points
- horizontal overlaps with another horizontal line on no points
- horizontal overlaps with another horizontal line on one point
- horizontal overlaps with another horizontal line on many points
- horizontal overlaps with another vertical line on no points
- horizontal overlaps with another vertical line on one point
- horizontal overlaps with other vertical lines on one point
- horizontal overlaps with other points on no points
- horizontal overlaps with other points on all points

- horizontal overlaps with two lines on x points
- horizontal overlaps with vertical on no points
- horizontal overlaps with vertical on 1 point
- vertical overlaps with vertical on no points
- vertical overlaps with vertical on one point
- vertical overlaps with vertical on x points
- vertical overlaps with horizontal on no points
- vertical overlaps with horizontal on 1 point

- no lines have no overlapping points
- drawing a line has no overlapping points
- drawing an intersecting line has one overlapping point
- drawing on top of another line has overlapping points
- a horizontal line with a horizontal line has up to x overlapping points
- a horizontal line with a vertical line has up to 1 overlapping point

Grid.DrawLine
Grid.DrawLine
Grid.DrawLine etc etc
Grid.NumberOfOverlappingPoints


## Map tests
