namespace AG.DS
{
    public class OptionPortCellFactory
    {
        /// <summary>
        /// Generate a new option port cell.
        /// </summary>
        /// <param name="model">The option port cell model to set for.</param>
        /// <param name="data">The option port cell data to set for.</param>
        /// <returns>A new option port cell.</returns>
        public static OptionPortCell Generate
        (
            OptionPortCellModel model,
            OptionPortCellData data = null
        )
        {
            var portCell = OptionPortCellPresenter.CreateElement(model);

            new OptionPortCellObserver(portCell).RegisterEvents();

            if (data != null)
            {
                OptionPortCellSerializer.Load(portCell, data);
            }

            return portCell;
        }
    }
}