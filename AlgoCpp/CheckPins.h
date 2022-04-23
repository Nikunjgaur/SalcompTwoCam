//  To parse this JSON data, first install
//
//      Boost     http://www.boost.org
//      json.hpp  https://github.com/nlohmann/json
//
//  Then include this file, and then do
//
//     CheckPins data = nlohmann::json::parse(jsonString);

#pragma once
#include<fstream>
#include<istream>
#include<iostream>
#include<string>
#include <nlohmann/json.hpp>


namespace CheckPins {
    using nlohmann::json;

    inline json get_untyped(const json& j, const char* property) {
        if (j.find(property) != j.end()) {
            return j.at(property).get<json>();
        }
        return json();
    }

    inline json get_untyped(const json& j, std::string property) {
        return get_untyped(j, property.data());
    }

    class PinRegion {
    public:
        PinRegion() = default;
        virtual ~PinRegion() = default;

    private:
        int64_t point_x;
        int64_t point_y;
        int64_t image_width;
        int64_t image_height;
        std::string template_image_path;

    public:
        const int64_t& get_point_x() const { return point_x; }
        int64_t& get_mutable_point_x() { return point_x; }
        void set_point_x(const int64_t& value) { this->point_x = value; }

        const int64_t& get_point_y() const { return point_y; }
        int64_t& get_mutable_point_y() { return point_y; }
        void set_point_y(const int64_t& value) { this->point_y = value; }

        const int64_t& get_image_width() const { return image_width; }
        int64_t& get_mutable_image_width() { return image_width; }
        void set_image_width(const int64_t& value) { this->image_width = value; }

        const int64_t& get_image_height() const { return image_height; }
        int64_t& get_mutable_image_height() { return image_height; }
        void set_image_height(const int64_t& value) { this->image_height = value; }

        const std::string& get_template_image_path() const { return template_image_path; }
        std::string& get_mutable_template_image_path() { return template_image_path; }
        void set_template_image_path(const std::string& value) { this->template_image_path = value; }
    };

    class CheckPin : public PinRegion {
    public:
        CheckPin() = default;
        virtual ~CheckPin() = default;

    private:
        std::vector<PinRegion> pin_regions;
        float angle_tolerance;
        int64_t threshold;
        int64_t distance;
        int64_t distance_tolerance;

    public:
        const std::vector<PinRegion>& get_pin_regions() const { return pin_regions; }
        std::vector<PinRegion>& get_mutable_pin_regions() { return pin_regions; }
        void set_pin_regions(const std::vector<PinRegion>& value) { this->pin_regions = value; }


        const float& get_angle_tolerance() const { return angle_tolerance; }
        float& get_mutable_angle_tolerance() { return angle_tolerance; }
        void set_angle_tolerance(const float& value) { this->angle_tolerance = value; }

        const int64_t& get_threshold() const { return threshold; }
        int64_t& get_mutable_threshold() { return threshold; }
        void set_threshold(const int64_t& value) { this->threshold = value; }

        const int64_t& get_distance() const { return distance; }
        int64_t& get_mutable_distance() { return distance; }
        void set_distance(const int64_t& value) { this->distance = value; }

        const int64_t& get_distance_tolerance() const { return distance_tolerance; }
        int64_t& get_mutable_distance_tolerance() { return distance_tolerance; }
        void set_distance_tolerance(const int64_t& value) { this->distance_tolerance = value; }
    };

    void from_json(const json& j, CheckPins::PinRegion& x);
    void to_json(json& j, const CheckPins::PinRegion& x);

    void from_json(const json& j, CheckPins::CheckPin& x);
    void to_json(json& j, const CheckPins::CheckPin& x);

    

    inline void from_json(const json& j, CheckPins::PinRegion& x) {
        x.set_point_x(j.at("point_x").get<int64_t>());
        x.set_point_y(j.at("point_y").get<int64_t>());
        x.set_image_width(j.at("imageWidth").get<int64_t>());
        x.set_image_height(j.at("imageHeight").get<int64_t>());
        x.set_template_image_path(j.at("template_image_path").get<std::string>());
    }

    inline void to_json(json& j, const CheckPins::PinRegion& x) {
        j = json::object();
        j["point_x"] = x.get_point_x();
        j["point_y"] = x.get_point_y();
        j["imageWidth"] = x.get_image_width();
        j["imageHeight"] = x.get_image_height();
        j["template_image_path"] = x.get_template_image_path();
    }

    inline void from_json(const json& j, CheckPins::CheckPin& x) {
        x.set_pin_regions(j.at("pinRegions").get<std::vector<CheckPins::PinRegion>>());
        x.set_angle_tolerance(j.at("angleTolerance").get<float>());
        x.set_threshold(j.at("threshold").get<int64_t>());
        x.set_distance(j.at("Distance").get<int64_t>());
        x.set_distance_tolerance(j.at("distanceTolerance").get<int64_t>());
    }

    inline void to_json(json& j, const CheckPins::CheckPin& x) {
        j = json::object();
        j["pinRegions"] = x.get_pin_regions();
        j["angleTolerance"] = x.get_angle_tolerance();
        j["threshold"] = x.get_threshold();
        j["Distance"] = x.get_distance();
        j["distanceTolerance"] = x.get_distance_tolerance();
    }

   
}



