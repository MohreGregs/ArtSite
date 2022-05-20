namespace ArtSite.Database.Entities; 

public class Like : BaseNameEntity {
    public virtual ISet<GeneralInfo> Likes { get; set; } = new HashSet<GeneralInfo>();
    public virtual ISet<GeneralInfo> Dislikes { get; set; } = new HashSet<GeneralInfo>();
}