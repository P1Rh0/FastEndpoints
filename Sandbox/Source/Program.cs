//ReSharper disable InconsistentNaming

var bld = WebApplication.CreateBuilder(args);
bld.Services
   .SwaggerDocument(
       o =>
       {
           o.DocumentSettings = d => d.DocumentName = "Release 0";
           o.ReleaseVersion = 0;
           o.ShowDeprecatedOps = true;
       })
   .SwaggerDocument(
       o =>
       {
           o.DocumentSettings = d => d.DocumentName = "Release 1";
           o.ReleaseVersion = 1;
           o.ShowDeprecatedOps = true;
       })
   .SwaggerDocument(
       o =>
       {
           o.DocumentSettings = d => d.DocumentName = "Release 2";
           o.ReleaseVersion = 2;
           o.ShowDeprecatedOps = true;
       })
   .SwaggerDocument(
       o =>
       {
           o.DocumentSettings = d => d.DocumentName = "Release 3";
           o.ReleaseVersion = 3;
           o.ShowDeprecatedOps = true;
       })
   .AddFastEndpoints();

var app = bld.Build();
app.UseFastEndpoints()
   .UseSwaggerGen();
app.Run();

sealed class GetAEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("endpoint-a");
        AllowAnonymous();
    }

    public override Task HandleAsync(CancellationToken c)
        => Task.CompletedTask;
}

sealed class GetAEndpoint_V1 : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("endpoint-a");
        AllowAnonymous();
        Version(1, deprecateAt: 2);
    }

    public override Task HandleAsync(CancellationToken c)
        => Task.CompletedTask;
}

sealed class GetAEndpoint_V2 : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("endpoint-a");
        AllowAnonymous();
        Version(2).StartingRelease(3);
    }

    public override Task HandleAsync(CancellationToken c)
        => Task.CompletedTask;
}

sealed class GetBEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("endpoint-b");
        AllowAnonymous();
    }

    public override Task HandleAsync(CancellationToken c)
        => Task.CompletedTask;
}

sealed class GetBEndpoint_V1 : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("endpoint-b");
        AllowAnonymous();
        Version(1).StartingRelease(2);
    }

    public override Task HandleAsync(CancellationToken c)
        => Task.CompletedTask;
}

sealed class DeleteBEndpoint_V1 : EndpointWithoutRequest
{
    public override void Configure()
    {
        Delete("endpoint-b");
        AllowAnonymous();
        Version(1).StartingRelease(2);
    }

    public override Task HandleAsync(CancellationToken c)
        => Task.CompletedTask;
}
