using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HairSalon.Core.Utils.Firebase
{
	public class ImageHelper
	{
		private readonly IConfiguration _configuration;

		public ImageHelper(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<string> Upload(IFormFile file)
		{
			if (file != null && file.Length > 0)
			{
				string firebaseUrl = "";
				// Use a MemoryStream to avoid saving the file locally
				using (var memoryStream = new MemoryStream())
				{
					await file.CopyToAsync(memoryStream);
					memoryStream.Position = 0; // Reset the stream position to the beginning

					firebaseUrl = await UploadToFirebase(memoryStream, file.FileName); // Get the download URL
				}
				return firebaseUrl;
			}
			return "";
		}


		public async Task<string> UploadToFirebase(Stream stream, string fileName)
		{
			// Access Firebase configuration from appsettings.json
			var apiKey = _configuration["Firebase:ApiKey"];
			var authEmail = _configuration["Firebase:AuthEmail"];
			var authPassword = _configuration["Firebase:AuthPassword"];
			var bucket = _configuration["Firebase:Bucket"];

			// Authenticate using FirebaseAuthProvider with credentials from configuration
			var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
			var signIn = await auth.SignInWithEmailAndPasswordAsync(authEmail, authPassword);
			var cancellation = new CancellationTokenSource();

			var task = new FirebaseStorage(
				bucket,
				new FirebaseStorageOptions
				{
					AuthTokenAsyncFactory = () => Task.FromResult(signIn.FirebaseToken),
					ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
				})
				.Child("images")
				.Child(fileName)
				.PutAsync(stream, cancellation.Token);

			task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

			try
			{
				string link = await task;
				return link;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception was thrown: {ex.Message}");
				return null;
			}
		}
	}
}
