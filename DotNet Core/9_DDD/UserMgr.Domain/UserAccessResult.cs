namespace UserMgr.Domain;

public enum UserAccessResult {
    Ok, PhoneNumberNotFound, Lockout, NoPassword, PasswordError
}