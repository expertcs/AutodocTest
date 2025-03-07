using Microsoft.AspNetCore.Mvc;

namespace AutodocTest.Controllers;

internal static class Extensions
{
    public static async Task<IActionResult> GetActionResult(this Task<int> resultTask, bool notFound = false)
    {
        var ret = await resultTask;
        if (ret > 0)
            return new OkResult();
        if (notFound)
            return new NotFoundResult();
        return new BadRequestResult();
    }

    public static async Task<byte[]> GetBytes(this IFormFile formFile, CancellationToken token)
    {
        using var s = formFile.OpenReadStream();
        using var ms = new MemoryStream();
        await s.CopyToAsync(ms, token);
        return ms.ToArray();
    }
}
