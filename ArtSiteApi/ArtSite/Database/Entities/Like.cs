namespace ArtSite.Database.Entities; 

public class Like : BaseNameEntity {
    public virtual ISet<GeneralInfo> GeneralInfosLike { get; set; } = new HashSet<GeneralInfo>();
    public virtual ISet<GeneralInfo> GeneralInfosDislike { get; set; } = new HashSet<GeneralInfo>();
}