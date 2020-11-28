namespace PandaSharp.Bamboo.Rest.Contract
{
    internal interface IBambooOptions
    {
        string BaseUrl { get; set; }

        IBambooAuthentication Authentication { get; }
    }
}