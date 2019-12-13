namespace PandaSharp.Rest.Contract
{
    internal interface IBambooOptions
    {
        string BaseUrl { get; set; }

        string UserName { get; set; }

        string Password { get; set; }
    }
}