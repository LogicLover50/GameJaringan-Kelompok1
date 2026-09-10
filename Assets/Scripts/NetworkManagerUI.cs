using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NetworkManagerUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private TextMeshProUGUI statusText;

    private void Awake()
    {
        // Menambahkan listener event pada tombol UI
        hostButton.onClick.AddListener(OnHostButtonClicked);
        clientButton.onClick.AddListener(OnClientButtonClicked);
    }

    private void OnHostButtonClicked()
    {
        // Menjalankan fungsi StartHost dari NetworkManager NGO
        if (NetworkManager.Singleton.StartHost())
        {
            UpdateUIStatus("Status: Connected as HOST");
        }
        else
        {
            UpdateUIStatus("Status: Failed to Start Host");
        }
    }

    private void OnClientButtonClicked()
    {
        // Menjalankan fungsi StartClient dari NetworkManager NGO
        if (NetworkManager.Singleton.StartClient())
        {
            UpdateUIStatus("Status: Connected as CLIENT");
        }
        else
        {
            UpdateUIStatus("Status: Failed to Start Client");
        }
    }

    private void UpdateUIStatus(string message)
    {
        if (statusText != null)
        {
            statusText.text = message;
        }

        // Menyembunyikan tombol pilihan setelah role dipilih
        hostButton.gameObject.SetActive(false);
        clientButton.gameObject.SetActive(false);
    }
}