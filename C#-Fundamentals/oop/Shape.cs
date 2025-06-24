abstract class Shape
{
    protected double height;
    protected double width;

    protected double radius;

    public Shape(double h, double w)
    {
        height = h;
        width = w;
    }

    public Shape(double r)
    {
        radius = r;
    }

    public abstract void printArea();

}