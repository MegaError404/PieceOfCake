namespace PieceOfCakeAPI.ModelsDTO.Merchant
{
	public struct MerchantRegisterRequest
	{
		public MerchantRegisterRequest()
		{
		}

		//GovernorateInfo
		public int GovernorateID { get; set; } = 0;

		//BusinessActivityInfo
		public int BusinessActivityID { get; set; } = 0;
		//SotreInfo
		public string SotreName { get; set; } = string.Empty;
		public string Logo { get; set; } = string.Empty;

		public string PrimaryNumberPhone { get; set; } = string.Empty;
		public string SecondaryNumberPhone { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string OnmapLocation { get; set; } = string.Empty;

		//MerchantInfo
		public string MerchantName { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string PrimaryPhoneNumber { get; set; } = string.Empty;
		public string SecondaryPhoneNumber { get; set; } = string.Empty;
	}
}
