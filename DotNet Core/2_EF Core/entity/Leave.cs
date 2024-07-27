namespace EF_Core.entity; 

public class Leave {
    public int Id { get; set; }
    public User Requester { get; set; }
    public User Approver { get; set; }
    public string Remark { get; set; }
}