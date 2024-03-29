﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Constants
{
    public static class Messages
    {
        //CarManager messages
        public static string CarAddedSuccess = "Car add has been successful";
        public static string CarAddedFailure = "Car add has not been successful";
        public static string CarUpdatedSuccess = "Car update has been successful";
        public static string CarUpdatedFailure = "Car update has not been successful";
        public static string CarDeletedSuccess = "Car delete has been successful";
        public static string CarDeletedFailure = "Car delete has not been successful";
        public static string CarListSuccess = "Car listing has been successful";
        public static string CarListByBrandSuccess = "Car listing by brand has been successful";
        public static string CarListByColorSuccess = "Car listing by color has been successful";
        public static string CarListByIdSuccess = "Car listing by car id has been successful";
        public static string CarBrandAndColorSuccess = "Car listing by brand id and color id has been successfull";

        //BrandManager messages
        public static string BrandAddedSuccess = "Brand add has been successful";
        public static string BrandAddedFailure = "Brand add has not been successful";
        public static string BrandUpdatedSuccess = "Brand update has been successful";
        public static string BrandUpdatedFailure = "Brand update has not been successful";
        public static string BrandDeletedSuccess = "Brand delete has been successful";
        public static string BrandDeletedFailure = "Brand delete has not been successful";
        public static string BrandListSuccess = "Brand listing has been successful";
        public static string BrandListByIdSuccess = "Brand listing by id has been successful";
        public static string BrandNameExists = "BrandName already exists.";

        //ColorManager messages
        public static string ColorAddedSuccess = "Color add has been successful";
        public static string ColorAddedFailure = "Color add has not been successful";
        public static string ColorUpdatedSuccess = "Color update has been successful";
        public static string ColorUpdatedFailure = "Color update has not been successful";
        public static string ColorDeletedSuccess = "Color delete has been successful";
        public static string ColorDeletedFailure = "Color delete has not been successful";
        public static string ColorListSuccess = "Color listing has been successful";
        public static string ColorListByIdSuccess = "Color listing by id has been successful";
        public static string ColorNameExists = "ColorName already exists.";

        //CustomerManager messages
        public static string CustomerAddedSuccess = "Customer add has been successful";
        public static string CustomerAddedFailure = "Customer add has not been successful";
        public static string CustomerUpdatedSuccess = "Customer update has been successful";
        public static string CustomerUpdatedFailure = "Customer update has not been successful";
        public static string CustomerDeletedSuccess = "Customer delete has been successful";
        public static string CustomerDeletedFailure = "Customer delete has not been successful";
        public static string CustomerListSuccess = "Customer listing has been successful";
        public static string CustomerListByIdSuccess = "Customer listing by id has been successful";

        //RentalManager messages
        public static string RentalAddedSuccess = "Rental add has been successful";
        public static string RentalAddedFailure = "Rental add has not been successful";
        public static string RentalUpdatedSuccess = "Rental update has been successful";
        public static string RentalUpdatedFailure = "Rental update has not been successful";
        public static string RentalDeletedSuccess = "Rental delete has been successful";
        public static string RentalDeletedFailure = "Rental delete has not been successful";
        public static string RentalListSuccess = "Rental listing has been successful";
        public static string RentalListByIdSuccess = "Rental listing by id has been successful";

        //RentalManager messages
        public static string UserAddedSuccess = "User add has been successful";
        public static string UserAddedFailure = "User add has not been successful";
        public static string UserUpdatedSuccess = "User update has been successful";
        public static string UserUpdatedFailure = "User update has not been successful";
        public static string UserDeletedSuccess = "User delete has been successful";
        public static string UserDeletedFailure = "User delete has not been successful";
        public static string UserListSuccess = "User listing has been successful";
        public static string UserListByIdSuccess = "User listing by id has been successful";

        //CarImageManager messages
        public static string CarImageLimit = "Car image is over 5 ";

        public static string AuthorizationDenied = "Invalid authorization detected!";
        public static string UserAlreadyExists = "User is already exists!";
        public static string UserNotFound = "User not found!";
        public static string WrongPassword = "User password is not correct!";
        public static string SuccessLogin = "User has been logged in successfully!";
        public static string TokenCreated = "Token has been created successfully!";
        public static string SuccessUserRegister = "User has been registered successfully!";
        public static string RentalDetailsListed = "Rental details has been listed successfully!";

        //CartitemManager messages
        public static string CartItemDeleted = "Car item deleted has been successfully";
        public static string CartItemInserted = "Car item inserted has been successfully";
        public static string CartItemUpdated = "Car item updated has been successfully";
        public static string CartItemListed = "Car item listed has been successfully";
    }
}
