using System;
using System.Linq;
using System.Text.RegularExpressions;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.Cpnm.Data.Addresses
{
    public interface IAddressFactory {
        IGeneralAddress Create(string candidateAddress);
        IGeneralAddress Create();
    }

    public class AddressFactory : IAddressFactory
    {
        private const string RegexCriteria = @"\/([\w-]*)";
        private const string RegexValidationCriteria = @"^CPNM_(\w*):";
        private const string CpnmAddressPreffix = "CPNM_#:";
        private static readonly Regex BreakerRegex = new Regex(RegexCriteria);
        private static readonly Regex ValidationRegex = new Regex(RegexValidationCriteria);

        private readonly IItemRepository _itemRepository;
        private readonly IPropValueRepository _propValueRepository;
        private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;
        private readonly IPropertyRepository _propertyRepository;

        public AddressFactory(IItemRepository itemRepository, IPropValueRepository propValueRepository, IUnitOfMeasureRepository unitOfMeasureRepository, IPropertyRepository propertyRepository)
        {
            _itemRepository = itemRepository;
            _propValueRepository = propValueRepository;
            _unitOfMeasureRepository = unitOfMeasureRepository;
            _propertyRepository = propertyRepository;
        }

        public IGeneralAddress Create(string candidateAddress)
        {
            if (!IsCpnmAddress(candidateAddress)) throw new ArgumentException();
            
            return ParseStringIntoAddressObject(candidateAddress);
        }

        public IGeneralAddress Create()
        {
            return null;
        }

        // Helper Functions to handle the address thing.

        private bool IsCpnmAddress(string candidate)
        {
            return CheckIfIsAddress(candidate);
        }

        private static string[] GetAddressParts(string candidateAddress)
        {
            if (candidateAddress == null)
                throw new ArgumentNullException();
            if (!CheckIfIsAddress(candidateAddress) || BreakerRegex.Matches(candidateAddress).Count == 0)
                throw new Exception("Endereco invalido.");

            var matches = BreakerRegex.Matches(candidateAddress);
            return (from Match match in matches
                    select match.Groups[1].Value).ToArray();
        }

        private static bool CheckIfIsAddress(string candidate)
        {
            return ValidationRegex.IsMatch(candidate);
        }

        private GeneralAddress.AddressType GetAddressType(string candidateAddress)
        {
            var matches = ValidationRegex.Matches(candidateAddress);
            return (GeneralAddress.AddressType)Enum.Parse(typeof(GeneralAddress.AddressType), matches[0].Groups[1].Value);
        }

        private IGeneralAddress ParseStringIntoAddressObject(string candidateAddress)
        //jesus, eu sou muito desatento. Gastei 2 horas por que nao percebi que estava com a regex (\/[\w-]*) ao inves de \/([\w-]*)
        {
            if (candidateAddress == null) throw new Exception("No address to parse!");
            var thisAddressType = GetAddressType(candidateAddress);

            switch (thisAddressType)
            {
                case GeneralAddress.AddressType.ValueRef:
                    return ParsePropValAddress(candidateAddress);
                case GeneralAddress.AddressType.PropNameRef:
                    return null;
                case GeneralAddress.AddressType.ItemNameRef:
                    return null;
                case GeneralAddress.AddressType.ItemTypeNameRef:
                    return null;
                case GeneralAddress.AddressType.AreaRef:
                    return null;
                case GeneralAddress.AddressType.SubAreaRef:
                    return null;
                case GeneralAddress.AddressType.ProjectRef:
                    return null;
                default:
                    throw new ArgumentException();
            }
        }

        private ValueRefAddress ParsePropValAddress(string candidateAddress)
        {
            var ids = GetAddressParts(candidateAddress);

            var itemIdString = ids[0];
            var propIdString = ids[1];
            var unitIdString = ids[2];
            var formatTypeString = ids[3];

            var itemId = new Guid(itemIdString);
            var propId = new Guid(propIdString);

            var propValue = _propValueRepository.GetByItemAndPropId(itemId, propId);

            var unitOfMeasure = unitIdString != ""
                                ? _unitOfMeasureRepository.GetById(new Guid(unitIdString))
                                : propValue.GetProperty.DefaultUnit;

            var formatType = (PropValue.FormatType)Enum.Parse(typeof(PropValue.FormatType), formatTypeString);

            return new ValueRefAddress(propValue, unitOfMeasure, formatType);
        }
    }
}
