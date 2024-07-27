using DotNet_Core._3_DI.res;

namespace DotNet_Core._3_DI; 

using Microsoft.Extensions.DependencyInjection;

public class UseDi {
    public void Use() {
        var service = new ServiceCollection();
        service.AddTransient<TestServiceImpl>();

        using var sp = service.BuildServiceProvider();
        var testServiceImpl = sp.GetService<TestServiceImpl>();

        if (testServiceImpl != null) {
            testServiceImpl.Name = "tom";
            testServiceImpl.SayHi();
        }
    }
}