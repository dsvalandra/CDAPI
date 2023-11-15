using System.Collections.Generic;

public class AddressDTO
{
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public int? AddressCategoryId { get; set; }
    public int AddressId { get; set; }
    public int? AddressStatusId { get; set; }
    public int AddressTypeId { get; set; }
    public string City { get; set; }
    public int? ClassificationId { get; set; }
    public int? CountryId { get; set; }
    public string County { get; set; }
    public int? CountyId { get; set; }
    public int CreatedById { get; set; }
    public string EndDate { get; set; }
    public List<object> HostValues { get; set; }
    public int HousingLoanBalanceAmount { get; set; }
    public bool IsTotalMonthlyExpense { get; set; }
    public int LengthAtAddress { get; set; }
    public int? LiabilityId { get; set; }
    public int ModifiedById { get; set; }
    public int MonthlyExpenseAmount { get; set; }
    public int ObjectId { get; set; }
    public string ObjectType { get; set; }
    public string PostalCode { get; set; }
    public string StartDate { get; set; }
    public string StateCode { get; set; }
    public int StateId { get; set; }
    public string Township { get; set; }
    public int? TownshipId { get; set; }
    public bool UpdateLiability { get; set; }
    public int USPSValidationId { get; set; }
}

public class ApplicantAccountNumberDTO
{
    public string AccountNumber { get; set; }
    public int ApplicantAccountNumberId { get; set; }
    public string? TIN { get; set; }
}

public class ApplicantDTO
{
    public string AccountNumber { get; set; }
    public string AccountNumberRaw { get; set; }
    public List<AccountProductMappingDTO> AccountProductMappings { get; set; }
    public List<AddressDTO> Addresses { get; set; }
    public double Age { get; set; }
    public object AnnualSales { get; set; }
    public List<ApplicantAccountNumberDTO> ApplicantAccountNumbers { get; set; }
    public string? TIN { get; set; }
    public int ApplicantId { get; set; }
    public int ApplicantTypeId { get; set; }
    public string? Email { get; set; }
    public bool ExcludeFromOFAC { get; set; }
    public bool ExcludeIDCheck { get; set; }
    public string FirstName { get; set; }
    public string FullName { get; set; }
    public string LastName { get; set; }
    public int PreferredContactMethodId { get; set; }
    public object? PrimaryRelationshipId { get; set; }
    public bool PrivacyIndicator { get; set; }
    public string? PrivacyType { get; set; }
}

public class AccountProductMappingDTO
{
    public int AccountProductId { get; set; }
    public int ApplicantId { get; set; }
    public int ApplicantTypeId { get; set; }
    public int ApplicationAccountProductApplicantId { get; set; }
    public int ApplicationAccountProductId { get; set; }
    public int CreatedById { get; set; }

    public int ModifiedById { get; set; }
    public List<object> HostValues { get; set; }
    
}

public class CheckDTO
{
    public int ApplicationAccountProductCheckId { get; set; }
    public int ApplicationAccountProductId { get; set; }
    public object CheckDesignId { get; set; }
    public string CheckImprintLine1 { get; set; }
    public string CheckImprintLine2 { get; set; }
    public string CheckImprintLine3 { get; set; }
    public string CheckImprintLine4 { get; set; }
    public string CheckImprintLine5 { get; set; }
    public string MICRNumber { get; set; }
}

public class CustomFieldDTO
{
    public string? DataType { get; set; }
    public string? Label { get; set; }
    public int MetaDataID { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
}

public class AccountDTO
{
    public int AccountBaseRateIndexId { get; set; }
    public string AccountNumber { get; set; }
    public int AccountPricingModelId { get; set; }
    public int AccountProductId { get; set; }
    public string AccountProductName { get; set; }
    public int AllowForTransfers { get; set; }
    public object Amount { get; set; }
    public List<AccountProductMappingDTO> ApplicantMappings { get; set; }
    public int ApplicationAccountProductId { get; set; }
    public int ApplicationId { get; set; }
    public List<object> AttachedDocuments { get; set; }
    public string ChargeMethod { get; set; }
    public CheckDTO Check { get; set; }
    public object ContributionCodeId { get; set; }
    public object ContributionYear { get; set; }
    public object CourtesyPayOptInId { get; set; }
    public int CreatedById { get; set; }
    public int CrossSellId { get; set; }
    public List<CustomFieldDTO> CustomFields { get; set; }
    public string Description { get; set; }
    public int DisbursementUserId { get; set; }
    public object DocSetId { get; set; }
    public List<object> DocumentVersions { get; set; }
    public object EStatementOptInId { get; set; }
    public List<object> Fees { get; set; }
    public List<object> Fundings { get; set; }
    public List<object> HostValues { get; set; }
    public string IMMTagPrefix { get; set; }
    public double InterestRate { get; set; }
    public bool InterestRateOverride { get; set; }
    public bool IsBaseShare { get; set; }
    public bool IsRequired { get; set; }
    public object MaturityDate { get; set; }
    public object MinimumOpeningBalance { get; set; }
    public int ModifiedById { get; set; }
    public string PaymentAccountNumber { get; set; }
    public bool SafeDepositBox { get; set; }
    public string SafeDepositBoxSize { get; set; }
    public string SafeDepositBranch { get; set; }
    public object SafeDepositPaymentDate { get; set; }
    public object StatementCycleId { get; set; }
    public int StatusId { get; set; }
    public int Term { get; set; }
    public int TotalFees { get; set; }
    public int ValidationModelId { get; set; }
    public object WebOriginationProductId { get; set; }
}

public class YourDTO
{
    public int SubProductId { get; set; }
    public int ApplicationTypeId { get; set; }
    public int SourceId { get; set; }
    public string? TIN { get; set; }
    public int TINTypeId { get; set; }
    public List<ApplicantDTO> Applicants { get; set; }
    public List<AccountDTO> AccountProducts { get; set; }
}
