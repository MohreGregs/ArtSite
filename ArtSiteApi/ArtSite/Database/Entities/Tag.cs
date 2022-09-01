﻿namespace ArtSite.Database.Entities; 

public class Tag : BaseNameEntity {
    public virtual Color? Color { get; set; }
    public virtual ISet<Character> Characters { get; set; } = new HashSet<Character>();
}