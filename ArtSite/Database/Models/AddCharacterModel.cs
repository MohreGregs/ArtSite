﻿using ArtSite.Database.Entities;
using ArtSite.Enums;

namespace ArtSite.Database.Models; 

public class AddCharacterModel {
    public string Name { get; set; }
    public byte Age { get; set; }
    public Sexuality Sexuality { get; set; }
    public Gender Gender { get; set; }
    public ISet<Tag> Tags { get; set; }
    public Species Species { get; set; }
}