# A simple procedural galaxy generator #

This is a simple procedural galaxy generator using Unity and C#.

The code is adapted from [Itinerant Games tumblr post](http://itinerantgames.tumblr.com/post/78592276402/a-2d-procedural-galaxy-with-c).
## Usage ##

Load project as usual in Unity.

When playing hit `Space` to create a random galaxy.

Values can be changed in the Inspector of the `GalaxyGenerator` GameObject

## Remarks ##
 
Although I use Unity Pro it should work in Unity Basic as well. I don't think any Pro only features are used.

The performance is not the best (`SetPixel()` and `Apply()` are expensive).

## Todo ##

- Additional random stars
