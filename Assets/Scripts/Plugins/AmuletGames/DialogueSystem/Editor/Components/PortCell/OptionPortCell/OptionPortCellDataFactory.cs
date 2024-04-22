namespace AG.DS
{
    public class OptionPortCellDataFactory
    {
        /// <summary>
        /// Generate a new option port cell data.
        /// </summary>
        /// <param name="cell">The option port cell to set for.</param>
        /// <returns>A new option port cell data.</returns>
        public static OptionPortCellData Generate(OptionPortCell cell)
        {
            var data = new OptionPortCellData();
            OptionPortCellSerializer.Save(cell, data);

            return data;
        }
    }
}