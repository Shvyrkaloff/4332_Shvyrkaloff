using System;

namespace Template_4332.Application
{
    /// <summary>
    /// Enum SkiServiceType
    /// </summary>
    public enum SkiServiceType
    {
        /// <summary>
        /// The rent
        /// </summary>
        Rent,

        /// <summary>
        /// The uphill
        /// </summary>
        Uphill,

        /// <summary>
        /// The training
        /// </summary>
        Training
    }

    /// <summary>
    /// Class SkiServiceTypeExtensions.
    /// </summary>
    public static class SkiServiceTypeExtensions
    {
        /// <summary>
        /// Converts to skiservicetype.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.Nullable&lt;SkiServiceType&gt;.</returns>
        public static SkiServiceType? ToSkiServiceType(this string str)
        {
            switch (str.Trim())
            {
                case "Прокат":
                {
                    return SkiServiceType.Rent;
                }
                case "Обучение":
                {
                    return SkiServiceType.Training;
                }
                case "Подъем":
                {
                    return SkiServiceType.Uphill;
                }
                default:
                {
                    return null;
                }
            }
        }
    }

    /// <summary>
    /// Class Entity.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
    }

    /// <summary>
    /// Class SkiService.
    /// Implements the <see cref="Template_4332.Application.Entity" />
    /// </summary>
    /// <seealso cref="Template_4332.Application.Entity" />
    public class SkiService : Entity
    {
        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        /// <value>The name of the service.</value>
        public string ServiceName { get; set; }
        /// <summary>
        /// Gets or sets the service code.
        /// </summary>
        /// <value>The service code.</value>
        public string ServiceCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>The type of the service.</value>
        public SkiServiceType ServiceType { get; set; }
        /// <summary>
        /// Gets or sets the price for hour.
        /// </summary>
        /// <value>The price for hour.</value>
        public decimal PriceForHour { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkiService"/> class.
        /// </summary>
        public SkiService() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkiService"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="serviceCode">The service code.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="priceForHour">The price for hour.</param>
        /// <exception cref="System.ArgumentException">Нет такого вида услуг - serviceType</exception>
        public SkiService(int id, string serviceName, string serviceCode, string serviceType, decimal priceForHour)
        {
            SkiServiceType? type = serviceType.ToSkiServiceType();

            if (type is null)
                throw new ArgumentException("Нет такого вида услуг", nameof(serviceType));

            Id = id;
            ServiceName = serviceName;
            ServiceCode = serviceCode;
            ServiceType = type.Value;
            PriceForHour = priceForHour;
        }
    }
}
