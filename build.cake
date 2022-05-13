var target = Argument("target", "Default");

Task("Default")
    .Does(() =>
{
    MSBuild("./GeTui-PushApi-ServerSDK-NetCore-V2.sln");
});



RunTarget(target);