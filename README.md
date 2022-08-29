# Winner Insanjaya - Tugas 7

Diklat 3 in 1 Agate x BDI Denpasar


***Before :***
![before1](https://github.com/winnerinsanjaya/Winner-Insanjaya---Tugas7---forest-view/blob/main/Screenshot/1.%20Before2.jpg?raw=true)

![Before2](https://github.com/winnerinsanjaya/Winner-Insanjaya---Tugas7---forest-view/blob/main/Screenshot/1.%20Before1.jpg?raw=true)

***After :***
![enter image description here](https://github.com/winnerinsanjaya/Winner-Insanjaya---Tugas7---forest-view/blob/main/Screenshot/After2.jpg?raw=true)

![enter image description here](https://github.com/winnerinsanjaya/Winner-Insanjaya---Tugas7---forest-view/blob/main/Screenshot/2.%20After1.jpg?raw=true)
#
## Tugas A BGM

***Soal 1** : Jika player memilih tombol pertama, maka game akan memainkan BGM yang tersedia dan sisa BGM yang tidak terpakai akan di unload.*

***AudioManager.cs***

    public void PlayBgm()
    {
        int randomAudio = Random.Range(0, _bgmAudioSource.Count);
        _bgmAudioSource[randomAudio].Play();
        UnloadBGM(randomAudio);
    }

    private void UnloadBGM(int index)
    {
        int indexRemove = 0;
        int loopTimes = _bgmAudioSource.Count;
        for (int i = 0; i < loopTimes; i++)
        {
            if (i == index)
            {
                indexRemove += 1;
            }
            if (i != index)
            {
                _bgmAudioSource.RemoveAt(indexRemove);
            }
        }
    }



***Soal 2** : Jika player memilih tombol kedua maka game tidak akan memainkan BGM sama sekali dan tidak ada audio clip yang dimuat.*

***AudioManager.cs***

    public void UnloadAllBGM()
    {
        _bgmAudioSource.Clear();
    }
***MenuLauncher.cs***

    private void OnWithoutAudioButtonClicked()
        {
            
            AudioManager.Instance.isAudioEnabled = false;
            AudioManager.Instance.UnloadAllBGM();
            SceneManager.LoadScene("Game");
        }
#
## Tugas B Sprite Atlas
***Soal** : Buatlah texture atlas yang berisi sprite yang dipakai button pada Main Menu.*

***Sprite Atlas***
![SpriteAtlas](https://github.com/winnerinsanjaya/Winner-Insanjaya---Tugas7---forest-view/blob/main/Screenshot/SpriteAtlas.jpg?raw=true)

## Tugas C ObjectPooling for Mushroom
***Soal** : Implementasikan konsep Object Pooling pada Mushroom Spawner di scene Game, dimana mushroom yang terspawn akan hilang setelah 3 detik.*

***MushroomSpawner.cs***

    [SerializeField]
    private List<GameObject> deactivedPool;
    [SerializeField]
    private Transform mushroomPool;
    
    private void SpawnMushroom()
    {
        if(deactivedPool.Count > 0)
        {
            GameObject actMushroom = deactivedPool[0];
            deactivedPool.RemoveAt(0);
            actMushroom.transform.position = gameObject.transform.position;
            Mushroom mScript = actMushroom.GetComponent<Mushroom>();
            mScript.SetStart();
        }
        if (deactivedPool.Count <= 0)
        {
            GameObject mushroom = Instantiate(objPrefab, transform.position, Quaternion.identity, mushroomPool);
            Mushroom mScript = mushroom.GetComponent<Mushroom>();
            mScript.SetSpawner(gameObject);
        }
    }

    public void AddDead(GameObject obj)
    {
        deactivedPool.Add(obj);
    }

***Mushroom.cs***

    private MushroomSpawner spawner;
    private float countdown = 3;
    
    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown < 0)
        {
            spawner.AddDead(gameObject);
            gameObject.SetActive(false);
        }
    }
    
    public void SetSpawner(GameObject obj)
    {
        spawner = obj.GetComponent<MushroomSpawner>();
    }

    public void SetStart()
    {
        countdown = 3;
        gameObject.SetActive(true);
    }
#
## Tugas 4 Static Batching
***Soal** : Lakukan optimasi dengan metode Static Batching dan bandingkan perbedaan performa sebelum dan sesudah melakukan Static Batching pada scene Menu dan Game.*
![enter image description here](https://github.com/winnerinsanjaya/Winner-Insanjaya---Tugas7---forest-view/blob/main/Screenshot/StaticBatching.jpg?raw=true)


# Tambahan

## Occlusion Culling
***Before***
![enter image description here](https://github.com/winnerinsanjaya/Winner-Insanjaya---Tugas7---forest-view/blob/main/Screenshot/beforeOcculsion.jpg?raw=true)
***After***
![enter image description here](https://github.com/winnerinsanjaya/Winner-Insanjaya---Tugas7---forest-view/blob/main/Screenshot/AdterOcclusion.jpg?raw=true)
