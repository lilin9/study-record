﻿namespace EF_Core.entity; 

public class Comment {
    public long Id { get; set; }
    public Article Article { get; set; }
    public string Message { get; set; }
}