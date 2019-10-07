using Dnn.CakeUtils;

public class PackagingPatterns {
    public string[] installExclude {get; set;}
    public string[] installInclude {get; set;}
    public string[] upgradeExclude {get; set;}
}

PackagingPatterns packagingPatterns;

Task("PreparePackaging")
    .Does(() =>
	{
        packagingPatterns = Newtonsoft.Json.JsonConvert.DeserializeObject<PackagingPatterns>(Utilities.ReadFile("./Build/Cake/packaging.json"));
	});

Task("CreateInstall")
	.IsDependentOn("CompileSource")
	.IsDependentOn("PreparePackaging")
	.Does(() =>
	{
        CreateDirectory(artifactsFolder);
        var files = GetFilesByPatterns(websiteFolder, new string[] {"**/*"}, packagingPatterns.installExclude);
        files.Add(GetFilesByPatterns(websiteFolder, packagingPatterns.installInclude));
        Information(files.Count);
        var packageZip = string.Format(artifactsFolder + "DNN_Platform_{0}_Install.zip", GetProductVersion());
        Zip(websiteFolder, packageZip, files);
	});

Task("CreateUpgrade")
	.IsDependentOn("CompileSource")
	.Does(() =>
	{
	});
    
Task("CreateSymbols")
	.IsDependentOn("CompileSource")
	.Does(() =>
	{
	});

Task("CreateDeploy")
	.IsDependentOn("CompileSource")
	.Does(() =>
	{
	});
