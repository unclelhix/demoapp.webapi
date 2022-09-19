using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Transports;

namespace DemoApplication.WebAPI.Services.ObjectMapping
{
    public interface IEmployeeMappingService
    {
        /// <summary>
        /// Map Transport to Employee
        /// </summary>
        /// <param name="transport"></param>
        /// <returns></returns>
        Employee MapToEmployee(EmployeeTransport transport); //
        /// <summary>
        /// Map to Entity, Use for updating record
        /// </summary>
        /// <param name="transport"></param>
        /// <param name="employeeEntity"></param>
        /// <returns></returns>
        Employee MapToEmployee(EmployeeTransport transport, Employee employeeEntity);

        /// <summary>
        /// Map Entity to Transport
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        EmployeeTransport MapToEmployeeTransport(Employee entity);
        /// <summary>
        /// Get list of Employees
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>Transport</returns>
        List<EmployeeTransport> MapToEmployeeTransport(List<Employee> entities);
    }
}
