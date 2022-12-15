# Drawsy 
Graphics editor project for "Design, Architecture and Construction of Software Systems" university course.  
The goal was to develop application that implements 5 or more programming patterns.

# Implemented patterns
+ __Singletone__: ```DrawingContext``` is a singletone class desinged to be a global access point for entire application
+ __Factory method__: Shapes instances such as Rectangles and Ellipses are created using factory
+ __Template method__: Base Figure class determines ```Draw()``` method as a sequence of calls ```DrawStroke()``` and ```Fill()``` if needed. 
+ __Strategy__: ```DrawingContext``` have a strategy, that determines how form must process ```MouseDown```, ```MouseMove``` and ```MouseUp``` events
+ __Decorator__: To implement drawing with a brush used a ```BrushTale``` class which derives from ```FigureDecorator```. ```FigureDecorator``` has a private filed of type ```Figure``` where decorated object is stored. Also it overrides ```Draw()``` method of a ```Figure``` in a way, where firstly decorated figure is Drawn, then ```Decorate()``` method is called. For example, ```BrushTale```'s ```Decorate()``` method draws an ellipse of the same color as decorated object. This allows nesting a lot of ```BrushTale``` inside of ```BrushTale``` leading for final figure to be a line 
