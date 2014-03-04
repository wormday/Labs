package com.swq.disastermonitoring;

import android.app.Activity;
import android.app.Service;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.IBinder;
import com.baidu.location.LocationClient;
import com.baidu.location.LocationClientOption;


public class LocationService extends Service {

	public LocationClient mLocationClient = null;
	public MyLocationListener myListener = new MyLocationListener();
	SharedPreferences preferences;
	@Override
	public IBinder onBind(Intent arg0) {
		// TODO Auto-generated method stub
		return null;
	}
	
	@Override
	public void onCreate()
	{
		super.onCreate();
		System.out.println("LocationService is Created");
		
	    mLocationClient = new LocationClient(getApplicationContext());     //����LocationClient��
	    mLocationClient.setAK("HGomeGAw8R5vGL9mwX8W99CC");
	    
	    
	    LocationClientOption option = new LocationClientOption();
	    option.setOpenGps(true);
	    //option.setAddrType("all");//���صĶ�λ���������ַ��Ϣ
	    option.setCoorType("bd09ll");//���صĶ�λ����ǰٶȾ�γ��,Ĭ��ֵgcj02
	    option.setScanSpan(120*1000);//���÷���λ����ļ��ʱ��Ϊ5000ms
	    option.disableCache(true);//��ֹ���û��涨λ
	    option.setPoiNumber(5);    //��෵��POI����   
	    option.setPoiDistance(1000); //poi��ѯ����        
	    option.setPoiExtraInfo(true); //�Ƿ���ҪPOI�ĵ绰�͵�ַ����ϸ��Ϣ        
	    mLocationClient.setLocOption(option);
	    preferences=getSharedPreferences("PRIVATE",Activity.MODE_PRIVATE);
	    myListener.userId=preferences.getString("Serial_Number", "unknow");
	    mLocationClient.registerLocationListener( myListener );
	    
	}
	
	@Override
	public int onStartCommand(Intent intent,int flags,int startId)
	{
		mLocationClient.start();
		if (mLocationClient != null && mLocationClient.isStarted())
			mLocationClient.requestLocation();
		else 
			System.out.println("mLocationClient is null or not started");
		
		System.out.println("LocationService is Started");
		return START_STICKY;
	}
	
	@Override
	public void onDestroy()
	{
		super.onDestroy();
		mLocationClient.stop();
		System.out.println("LocationService is Destroyed");
	}

}
