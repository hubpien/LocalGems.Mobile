# LocalGems

Dokumentacja Wdrażania
Przygotowanie Środowiska Azure:

Upewnij się, że posiadasz subskrypcję Azure.
Zainstaluj i skonfiguruj Azure CLI lub użyj Azure Cloud Shell do zarządzania zasobami.
Tworzenie Grupy Zasobów:

Użyj Azure CLI lub portalu Azure do utworzenia nowej grupy zasobów, jeśli jeszcze nie istnieje. Wykorzystaj nazwę i lokalizację zdefiniowaną w profile.arm.json.
Wdrażanie Szablonu ARM:

Wykorzystaj Azure CLI lub portal Azure do wdrożenia szablonów ARM (apis1.arm.json i profile.arm.json).
Upewnij się, że ścieżki do plików JSON są dostępne i poprawne.
Przykładowe polecenie w Azure CLI do wdrożenia szablonu:

```
bash
az deployment group create --resource-group <nazwa_grupy_zasobów> --template-file <ścieżka_do_pliku_json> --parameters <parametry_wdrażania>
```
Weryfikacja Zasobów:

Po wdrożeniu szablonów, użyj Azure CLI lub portalu Azure do weryfikacji utworzonych zasobów.
Sprawdź, czy wszystkie zasoby są poprawnie skonfigurowane zgodnie z definicjami w szablonach ARM.
Konfiguracja Dodatkowa:

W razie potrzeby dokonaj dodatkowej konfiguracji zasobów, takich jak ustawienia sieci, polityki bezpieczeństwa czy monitorowanie.
Dokumentacja i Utrzymanie:

Utrzymuj dokumentację wdrażania aktualną, odnotowując wszelkie zmiany w konfiguracji zasobów lub aktualizacje szablonów ARM.