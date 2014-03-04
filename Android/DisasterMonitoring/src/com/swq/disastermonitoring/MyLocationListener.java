package com.swq.disastermonitoring;


import android.util.Log;
import com.baidu.location.BDLocation;
import com.baidu.location.BDLocationListener;

public class MyLocationListener implements BDLocationListener {
	public String userId;

	@Override
	public void onReceiveLocation(BDLocation location) {
		if (location == null)
			return;
		Log.i("MyLocationListener", "location:"+location.getLatitude()+","+location.getLongitude()+","+userId);
		NetThread net = new NetThread(location.getLatitude(),
				location.getLongitude(), userId);
		new Thread(net).start();
		Log.i("MyLocationListener", "位置信息已提交服务器");
	}

	public void onReceivePoi(BDLocation poiLocation) {
		if (poiLocation == null) {
			return;
		}
		StringBuffer sb = new StringBuffer(256);
		sb.append("Poi time : ");
		sb.append(poiLocation.getTime());
		sb.append("\nerror code : ");
		sb.append(poiLocation.getLocType());
		sb.append("\nlatitude : ");
		sb.append(poiLocation.getLatitude());
		sb.append("\nlontitude : ");
		sb.append(poiLocation.getLongitude());
		sb.append("\nradius : ");
		sb.append(poiLocation.getRadius());
		if (poiLocation.getLocType() == BDLocation.TypeNetWorkLocation) {
			sb.append("\naddr : ");
			sb.append(poiLocation.getAddrStr());
		}
		if (poiLocation.hasPoi()) {
			sb.append("\nPoi:");
			sb.append(poiLocation.getPoi());
		} else {
			sb.append("noPoi information");
		}
		System.out.println(sb.toString());
	}
}