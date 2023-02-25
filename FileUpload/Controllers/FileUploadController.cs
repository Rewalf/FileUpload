using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FileUpload.Controllers
{
    public class FileUploadController : ApiController
    {

        public async Task<IHttpActionResult> PostFormData()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                return ResponseMessage(new HttpResponseMessage { StatusCode = HttpStatusCode.UnsupportedMediaType });
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data.
                _ = await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.

                var files = provider.FileData.Select(x => new { 
                    x.Headers.ContentDisposition.FileName, 
                    x.LocalFileName
                });
                return Ok(new
                {
                    files
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
