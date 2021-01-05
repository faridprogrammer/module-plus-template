using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Abp.Configuration;
using AbpCompanyName.AbpProjectName.Configuration;
using AbpCompanyName.AbpProjectName.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AbpCompanyName.AbpProjectName.Controllers
{
    public class DocumentsController : AbpProjectNameControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(CancellationToken cancellationToken)
        {
            try
            {
                var rootPath = await SettingManager.GetSettingValueForApplicationAsync(AppSettingNames.DocumentsRootPath);
                var maxSize = await SettingManager.GetSettingValueForApplicationAsync<int>(AppSettingNames.DocumentsMaxSizeMb);
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("UploadedFiles");
                var pathToSave = Path.Combine(rootPath, folderName);

                if (file.Length > 0)
                {
                    if ((file.Length / 1024 / 1024) > maxSize)
                    {
                        Logger.Error($"File size limit exceed");
                        return StatusCode(500, "File size limit exceed");
                    }

                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var fullPath = Path.Combine(pathToSave, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream, cancellationToken);
                    }

                    return Ok(new
                    {
                        fileName
                    });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error in upload file", ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
        {
            try
            {
                var rootPath = await SettingManager.GetSettingValueForApplicationAsync(AppSettingNames.DocumentsRootPath);
                var folderName = Path.Combine("UploadedFiles");
                var pathToGet = Path.Combine(rootPath, folderName);
                var filePath = Path.Combine(pathToGet, id);
                if (!System.IO.File.Exists(filePath))
                    return StatusCode(400, "Document not found.");
                var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath, cancellationToken);
                var extension = Path.GetExtension(id).ToLower();
                return File(fileBytes, MimeTypeMap.GetMimeType(extension), id);
            }
            catch (Exception ex)
            {
                Logger.Error("Error in getting file", ex);
                return StatusCode(500);
            }
        }
    }
}
