using Azure.Storage.Blobs;

namespace PhotoAlbumApp.Services;

public class BlobService
{
    private readonly BlobContainerClient _container;

    public BlobService(IConfiguration configuration)
    {
        var connectionString = configuration["BlobStorageConnection"];
        var blobServiceClient = new BlobServiceClient(connectionString);

        _container = blobServiceClient.GetBlobContainerClient("photos");
    }

    public async Task<string> UploadAsync(Stream fileStream, string fileName)
    {
        var blobClient = _container.GetBlobClient(fileName);
        await blobClient.UploadAsync(fileStream, overwrite: true);
        return blobClient.Uri.ToString();
    }

    public async Task DeleteAsync(string fileName)
    {
        var blobClient = _container.GetBlobClient(fileName);
        await blobClient.DeleteIfExistsAsync();
    }
}