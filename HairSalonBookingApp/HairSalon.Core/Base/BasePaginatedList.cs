namespace HairSalon.Core
{
	public class BasePaginatedList<T>
	{
		public IReadOnlyCollection<T> Items { get; set; } = new List<T>();

		public int TotalItems { get; set; }

		public int CurrentPage { get; set; }

		public int TotalPages { get; set; }

		public int PageSize { get; set; }

		// Parameterless constructor for deserialization
		public BasePaginatedList() { }

		public BasePaginatedList(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
		{
			TotalItems = count;
			CurrentPage = pageNumber;
			PageSize = pageSize;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);
			Items = items;
		}

		public bool HasPreviousPage => CurrentPage > 1;

		public bool HasNextPage => CurrentPage < TotalPages;
	}
}
