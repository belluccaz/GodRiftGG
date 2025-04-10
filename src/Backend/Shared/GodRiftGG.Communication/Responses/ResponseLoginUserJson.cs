using System;

namespace GodRiftGG.Communication.Requests;

public class ResponseLoginUserJson
{
    private string Name { get; set; } = string.Empty;
    private string Email { get; set; } = string.Empty;
    private string Password { get; set; } = string.Empty;
}
