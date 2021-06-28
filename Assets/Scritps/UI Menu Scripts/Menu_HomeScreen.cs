﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_HomeScreen : MonoBehaviour {

    public static Menu_HomeScreen instance;
    public GameObject MainMenu;
    public GameObject WorldChoose;
    public GameObject World1;
    public GameObject World2;
    public GameObject Loading;
    public GameObject musicRedLine, soundRedLine;

    int worldReached;

	void Awake () {
        instance = this;
        MainMenu.SetActive(true);
        WorldChoose.SetActive(false);
        World1.SetActive(false);
        World2.SetActive(false);
        Loading.SetActive(false);
    }

    void Start()
    {
        worldReached = PlayerPrefs.GetInt("WorldReached", 1);  
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	}

    public void MusicONOrOFF()
    {
        if (!GlobalValue.isMusic)
        {
            GlobalValue.isMusic = true;
            musicRedLine.SetActive(true);
        }
        else
        {
            GlobalValue.isMusic = false;
            musicRedLine.SetActive(false);
        }
    }

    public void SoundONOrOFF()
    {
        if (!GlobalValue.isSound)
        {
            GlobalValue.isSound = true;
            soundRedLine.SetActive(true);
        }
        else
        {
            GlobalValue.isSound = false;
            soundRedLine.SetActive(false);
        }
    }

    public void Play()
    {
        MainMenu.SetActive(false);
        WorldChoose.SetActive(true);
    }

    public void Menu()
    {
        MainMenu.SetActive(true);
        WorldChoose.SetActive(false);
        World1.SetActive(false);
        World2.SetActive(false);
    }

    public void ShowWorld1()
    {
        GlobalValue.worldPlaying = 1;
        World1.SetActive(true);
        WorldChoose.SetActive(false);
    }

    public void ShowWorld2()
    {
        if (worldReached < 2)
            return;

        GlobalValue.worldPlaying = 2;
        World2.SetActive(true);
        WorldChoose.SetActive(false);
    }

    public void LoadLevel(string nameScene)
    {
        Loading.SetActive(true);
        StartCoroutine(WaitTilPlay(nameScene));
    }

    IEnumerator WaitTilPlay(string nameScene)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nameScene);
    }

}
