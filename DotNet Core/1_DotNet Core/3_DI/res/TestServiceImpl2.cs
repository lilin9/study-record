﻿namespace DotNet_Core._3_DI.res; 

public class TestServiceImpl2: ITestService {
    public string Name { get; set; }
    
    public void SayHi() {
        Console.WriteLine($"你好, 我是 {Name}");
    }
}