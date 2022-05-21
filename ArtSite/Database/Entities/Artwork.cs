namespace ArtSite.Database.Entities; 
﻿using ArtSite.Enums;

namespace ArtSite.Database.Entities; 

public class Artwork : BaseEntity{
    public byte[] Description { get; set; }
    public byte[] File { get; set; }
    public string Extension { get; set; }
    public Rating Rating { get; set; }

    public virtual ISet<Artist> Artists { get; set; } = new HashSet<Artist>();
    
    public virtual ISet<Character> Characters { get; set; } = new HashSet<Character>();
    public virtual Reference Reference { get; set; }
}