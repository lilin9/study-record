namespace UserMgr.Domain;

public enum CheckCodeResult {
    Ok, PhoneNumberNotFound, Lockout, CodeError
}