using System;
using System.Linq;
using System.Text.RegularExpressions;
using Chemtech.CPNM.BR.AddressHandling.Addresses;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.BR.AddressHandling
{
    public interface IAddressFactory
    {
        IAddress Create(string candidateAddress);
        IAddress Create(IAddressDefiner addressDefiner);
    }

    public class AddressObjFactory : IAddressFactory
    {
        private const string RegexCriteria = @"\/([\w-]*)";
        private const string RegexValidationCriteria = @"CPNM_(\w*):";
        private static readonly Regex BreakerRegex = new Regex(RegexCriteria);
        private static readonly Regex ValidationRegex = new Regex(RegexValidationCriteria);

        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;
        private readonly IPropertyRepository _propertyRepository;

        public AddressObjFactory(IItemRepository itemRepository, IUnitOfMeasureRepository unitOfMeasureRepository, IPropertyRepository propertyRepository)
        {
            _itemRepository = itemRepository;
            _unitOfMeasureRepository = unitOfMeasureRepository;
            _propertyRepository = propertyRepository;
        }

        public IAddress Create(string candidateAddress)
        {
            if (!IsCpnmAddress(candidateAddress)) throw new ArgumentException();

            return ParseStringIntoAddressObject(candidateAddress);
        }

        public IAddress Create(IAddressDefiner addressDefiner)
        {
            if (addressDefiner == null) throw new ArgumentNullException();

            switch (addressDefiner.ThisAddressType)
            {
                case AddressType.ValueRef:
                    return new ValueRefAddress(addressDefiner.Item, addressDefiner.Property, addressDefiner.UnitOfMeasure, addressDefiner.FormatType);
                case AddressType.ProjectRef:
                    throw new NotImplementedException();
                case AddressType.AreaRef:
                    throw new NotImplementedException();
                case AddressType.ItemTypeNameRef:
                    throw new NotImplementedException();
                case AddressType.SubAreaRef:
                    throw new NotImplementedException();
                case AddressType.PropNameRef:
                    throw new NotImplementedException();
                case AddressType.ItemNameRef:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException();
            }
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

        private AddressType GetAddressType(string candidateAddress)
        {
            var matches = ValidationRegex.Matches(candidateAddress);
            return (AddressType)Enum.Parse(typeof(AddressType), matches[0].Groups[1].Value);
        }

        private IAddress ParseStringIntoAddressObject(string candidateAddress)
        //jesus, eu sou muito desatento. Gastei 2 horas por que nao percebi que estava com a regex (\/[\w-]*) ao inves de \/([\w-]*)
        {
            if (candidateAddress == null) throw new Exception("No address to parse!");
            var thisAddressType = GetAddressType(candidateAddress);

            switch (thisAddressType)
            {
                case AddressType.ValueRef:
                    return ParsePropValAddress(candidateAddress);
                case AddressType.PropNameRef:
                    return null;
                case AddressType.ItemNameRef:
                    return null;
                case AddressType.ItemTypeNameRef:
                    return null;
                case AddressType.AreaRef:
                    return null;
                case AddressType.SubAreaRef:
                    return null;
                case AddressType.ProjectRef:
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

            var item = _itemRepository.GetById(itemId);
            var prop = _propertyRepository.GetById(propId);

            var unitOfMeasure = unitIdString != ""
                                ? _unitOfMeasureRepository.GetById(new Guid(unitIdString))
                                : prop.DefaultUnit;

            var formatType = (FormatType)Enum.Parse(typeof(FormatType), formatTypeString);

            return new ValueRefAddress(item, prop, unitOfMeasure, formatType);
        }
    }
}
