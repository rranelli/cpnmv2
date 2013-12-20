using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Chemtech.CPNM.BR.AddressHandling;
using Chemtech.CPNM.BR.ReuseLogic;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Interface.ViewModels
{
    class SetupReuseViewModel : ViewModelBase, ISetupReuseViewModel, INotifyPropertyChanged
    {
        private readonly IAddressFactory _addressFactory;
        private readonly IItemRepository _itemRepository;
        private ObservableCollection<Item> _existantItems;
        private ObservableCollection<Item> _candidateItems;
        private ObservableCollection<ItemReusePair> _reuseQueue;
        private Item _selectedOrigin;
        private Item _selectedCandidate;
        private ItemReusePair _selectedItemReusePair;
        private bool _isRestrictedToSelection;
        private bool _isColorChanges;

        public SetupReuseViewModel(Window view, IEnumerable<Item> existantItems, IAddressFactory addressFactory, IItemRepository itemRepository)
            : base(view)
        {
            _addressFactory = addressFactory;
            _itemRepository = itemRepository;
            _reuseQueue = new ObservableCollection<ItemReusePair>();
            ExistantItems = new ObservableCollection<Item>(existantItems);
        }

        public void AddPairToQueue()
        {
            ReuseQueue.Add(new ItemReusePair(SelectedOrigin, SelectedCandidate));
            OnPropertyChanged("ReuseQueue");
        }

        public void RemovePairFromQueue()
        {
            ReuseQueue.Remove(SelectedItemReusePair);
            OnPropertyChanged("ReuseQueue");
        }

        public ObservableCollection<Item> ExistantItems
        {
            get { return _existantItems; }
            set
            {
                _existantItems = value;
                OnPropertyChanged("ExistantItems");
            }
        }

        public ObservableCollection<Item> CandidateItems
        {
            get { return _candidateItems; }
            set
            {
                _candidateItems = value;
                OnPropertyChanged("CandidateItems");
            }
        }

        public ObservableCollection<ItemReusePair> ReuseQueue
        {
            get { return _reuseQueue; }
            set
            {
                _reuseQueue = value;
                OnPropertyChanged("ReuseQueue");
            }
        }

        public Item SelectedOrigin
        {
            get { return _selectedOrigin; }
            set
            {
                _selectedOrigin = value;
                CandidateItems = new ObservableCollection<Item>(_itemRepository.GetByType(SelectedOrigin.ItemType));
                OnPropertyChanged("SelectedOrigin");
            }
        }

        public Item SelectedCandidate
        {
            get { return _selectedCandidate; }
            set
            {
                _selectedCandidate = value;
                OnPropertyChanged("SelectedCandidate");
            }
        }

        public ItemReusePair SelectedItemReusePair
        {
            get { return _selectedItemReusePair; }
            set
            {
                _selectedItemReusePair = value;
                OnPropertyChanged("SelectedItemReusePair");
            }
        }

        public bool IsRestrictedToSelection
        {
            get { return _isRestrictedToSelection; }
            set
            {
                _isRestrictedToSelection = value;
                OnPropertyChanged("IsRestrictedToSelection");
            }
        }

        public bool IsColorChanges
        {
            get { return _isColorChanges; }
            set
            {
                _isColorChanges = value;
                OnPropertyChanged("IsColorChanges");
            }
        }

        public IReuseHandler GetReuseDefinition()
        {
            return new ReuseHandler(ReuseQueue, _addressFactory);
        }

        public override bool ResultOk()
        {
            return ReuseQueue.Count > 0;
        }
    }
}
