namespace GeoInfo
{
    public class CollectionViewModel<T>
    {
        public CollectionViewModel(IEnumerable<T> data, int count)
        {
            Data = data;
            TotalCount = count;
        }

        public IEnumerable<T> Data { get; set; }

        public int TotalCount { get; set; }
    }
}
