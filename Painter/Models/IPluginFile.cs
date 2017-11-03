namespace Painter.Models
{
    public interface IPluginFile : IPlugin
    {
        string Serialize(MTab mTab);
        MTab Deserialize(string str);
    }
}
