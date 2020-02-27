using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameServices
{
    public class ServiceManager : MonoBehaviour
    {
        // Start thr Singleton
        public static ServiceManager instance;

        private List<IService> _serviceManagers = new List<IService>();

        private void Start()
        {
            MakeSingleton();
        }

        private void MakeSingleton()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                InitializeServices();
            }
        }
        // End of thr Singleton

        public static AdService Ads { get; private set; }

        private void InitializeServices()
        {
            Ads = GetComponent<AdService>();
            _serviceManagers.Add(Ads);

            foreach (IService service in _serviceManagers)
            {
                service.Initialize();
            }
        }
    }
}
