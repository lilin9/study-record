namespace UserMgr.Domain.Entities;

public record UserAccessFail {
    public Guid Id { get; init; }
    public Guid UserId { get; init; }   //用户Id
    public User User { get; init; } //用户
    private bool isLockOut;   //是否锁定
    public DateTime? LockEnd { get; private set; }
    public int AccessFailedCount { get; private set; }

    private UserAccessFail() {
    }

    public UserAccessFail(User user) {
        User = user;
        UserId = Guid.NewGuid();
    }

    public void Reset() {
        AccessFailedCount = 0;
        LockEnd = null;
        isLockOut = false;
    }

    public void Fail() {
        AccessFailedCount++;
        if (AccessFailedCount >= 3) {
            LockEnd = DateTime.Now.AddMinutes(5);
            isLockOut = true;
        }
    }

    public bool IsLockOut() {
        if (isLockOut) {
            if (DateTime.Now > LockEnd) {
                Reset();
                return false;
            } else {
                return true;
            }
        }

        return false;
    }
}