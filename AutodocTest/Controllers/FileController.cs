﻿using AutodocTest.Dal.Model;
using AutodocTest.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace AutodocTest.Controllers;

[Route("[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;
    private readonly IContentTypeProvider _contentTypeProvider;

    public FileController(
        IFileService fileService,
        IContentTypeProvider contentTypeProvider)
    {
        _fileService = fileService;
        _contentTypeProvider = contentTypeProvider;
    }



    [HttpPost("{taskId}")]
    public async Task<IActionResult> AddFile([FromRoute] int taskId, [FromForm] FormFile formFile, CancellationToken token)
    {
        var file = new FileBody
        {
            Name = formFile.Name,
            Body = await formFile.GetBytes(token),
            TaskInfo = new TaskInfo { Id = taskId }
        };
        return await _fileService.AddFile(file, token).GetActionResult();
    }

    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteFile([FromRoute] int id, CancellationToken token)
        => _fileService.DeleteFile(id, token).GetActionResult(true);

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFile([FromRoute] int id, CancellationToken token)
    {
        var file = await _fileService.GetFile(id, token);
        if (file == null)
            return NotFound();
        _contentTypeProvider.TryGetContentType(file.Name, out var contentType);
        return File(file.Body, contentType ?? "application/octet-stream");
    }
}
