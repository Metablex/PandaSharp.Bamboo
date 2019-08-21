namespace PandaSharp.Rest.Contract
{
    public interface IBambooOptions
    {
        string BaseUrl { get; }

        string UserName { get; }

        string Password { get; }
    }
}