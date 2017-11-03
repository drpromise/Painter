namespace Painter.Models
{
    public interface IPlugin
    {
        string Name { get; }
		bool Enabled { get; set; }
    }
}
