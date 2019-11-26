namespace PandaSharp.Rest.Contract
{
    internal interface IBambooOptions
    {
        string BaseUrl { get; }

        string UserName { get; }

        string Password { get; }
    }
}