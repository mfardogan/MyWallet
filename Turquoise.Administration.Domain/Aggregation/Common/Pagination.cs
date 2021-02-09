namespace Turquoise.Administration.Domain.Aggregation.Common
{
    public class Pagination
    {
        public Pagination() => (Page, Rows) = (1, 10);
        public Pagination(int page, int rows) => (Page, Rows) = (page, rows);

        private int page;
        public int Page
        {
            get => page > 0 ? page : 1;
            set => page = value;
        }

        private int rows;
        public int Rows
        {
            get => rows > 0 ? rows : 10;
            set => rows = value;
        }
    }
}
