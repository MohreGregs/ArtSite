﻿namespace ArtSite.Database.Entities; 

public class User : BaseEntity{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string Token { get; set; }
    public DateTimeOffset ValidUntil { get; set; }
}